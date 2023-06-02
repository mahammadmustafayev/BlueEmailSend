using sib_api_v3_sdk.Api;
using sib_api_v3_sdk.Client;
using sib_api_v3_sdk.Model;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace Blue;

internal class Program
{
    static void Main(string[] args)
    {
        string mail= "mahammadvm@code.edu.az";
        SenderEmail(mail);
        
    }
    static void SendEmail(string email)
    {
        Configuration.Default.ApiKey.Add("api-key", "xsmtpsib-ca1484379dabc951797e5a3add9d855e0929f6c09bfc05c70ee44d1815382cae-nMGNvHrtWL0VsQZ4");
        var apiInstance = new TransactionalEmailsApi();
        var sendSmtpEmail = new SendSmtpEmail
        {
            Sender= new SendSmtpEmailSender("mahammad", "mustafamehmed1251@gmail.com"),
            To=new List<SendSmtpEmailTo> { new SendSmtpEmailTo(email) },
            Subject="Test send",
            HtmlContent="<b>Working</b>"
        };
        try
        {
            var result = apiInstance.SendTransacEmail(sendSmtpEmail);
            Console.WriteLine("success");
            Console.WriteLine("Message Id:"+result.MessageId);
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message);
        }
    }
    static void SenderEmail(string email)
    {
        Configuration.Default.ApiKey.Add("api-key", "xsmtpsib-ca1484379dabc951797e5a3add9d855e0929f6c09bfc05c70ee44d1815382cae-nMGNvHrtWL0VsQZ4");

        var apiInstance = new TransactionalEmailsApi();
        string SenderName = "John Doe";
        string SenderEmail = "example@example.com";
        SendSmtpEmailSender Email = new SendSmtpEmailSender(SenderName, SenderEmail);
        string ToEmail = "example1@example1.com";
        string ToName = "John Doe";
        SendSmtpEmailTo smtpEmailTo = new SendSmtpEmailTo(ToEmail, ToName);
        List<SendSmtpEmailTo> To = new List<SendSmtpEmailTo>();
        To.Add(smtpEmailTo);
        string BccName = "Janice Doe";
        string BccEmail = "example2@example2.com";
        SendSmtpEmailBcc BccData = new SendSmtpEmailBcc(BccEmail, BccName);
        List<SendSmtpEmailBcc> Bcc = new List<SendSmtpEmailBcc>();
        Bcc.Add(BccData);
        string CcName = "John Doe";
        string CcEmail = "example3@example2.com";
        SendSmtpEmailCc CcData = new SendSmtpEmailCc(CcEmail, CcName);
        List<SendSmtpEmailCc> Cc = new List<SendSmtpEmailCc>();
        Cc.Add(CcData);
        string HtmlContent = "<html><body><h1>This is my first transactional email {{params.parameter}}</h1></body></html>";
        string TextContent = null;
        string Subject = "My {{params.subject}}";
        string ReplyToName = "John Doe";
        string ReplyToEmail = "replyto@domain.com";
        SendSmtpEmailReplyTo ReplyTo = new SendSmtpEmailReplyTo(ReplyToEmail, ReplyToName);
        string AttachmentUrl = null;
        string stringInBase64 = "aGVsbG8gdGhpcyBpcyB0ZXN0";
        byte[] Content = System.Convert.FromBase64String(stringInBase64);
        string AttachmentName = "test.txt";
        SendSmtpEmailAttachment AttachmentContent = new SendSmtpEmailAttachment(AttachmentUrl, Content, AttachmentName);
        List<SendSmtpEmailAttachment> Attachment = new List<SendSmtpEmailAttachment>();
        Attachment.Add(AttachmentContent);
        JObject Headers = new JObject();
        Headers.Add("Some-Custom-Name", "unique-id-1234");
        long? TemplateId = null;
        JObject Params = new JObject();
        Params.Add("parameter", "My param value");
        Params.Add("subject", "New Subject");
        List<string> Tags = new List<string>();
        Tags.Add("mytag");
        SendSmtpEmailTo1 smtpEmailTo1 = new SendSmtpEmailTo1(ToEmail, ToName);
        List<SendSmtpEmailTo1> To1 = new List<SendSmtpEmailTo1>();
        To1.Add(smtpEmailTo1);
        Dictionary<string, object> _parmas = new Dictionary<string, object>();
        _parmas.Add("params", Params);
        SendSmtpEmailReplyTo1 ReplyTo1 = new SendSmtpEmailReplyTo1(ReplyToEmail, ReplyToName);
        SendSmtpEmailMessageVersions messageVersion = new SendSmtpEmailMessageVersions(To1, _parmas, Bcc, Cc, ReplyTo1, Subject);
        List<SendSmtpEmailMessageVersions> messageVersiopns = new List<SendSmtpEmailMessageVersions>();
        messageVersiopns.Add(messageVersion);
        try
        {
            var sendSmtpEmail = new SendSmtpEmail(Email, To, Bcc, Cc, HtmlContent, TextContent, Subject, ReplyTo, Attachment, Headers, TemplateId, Params, messageVersiopns, Tags);
            CreateSmtpEmail result = apiInstance.SendTransacEmail(sendSmtpEmail);
            Debug.WriteLine(result.ToJson());
            Console.WriteLine(result.ToJson());
            Console.ReadLine();
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            Console.WriteLine(e.Message);
            Console.ReadLine();
        }
    }
}