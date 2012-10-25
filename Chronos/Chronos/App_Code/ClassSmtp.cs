//	---------------------------------------------------------------------------
//	$Filename: D:\DotNet\TS\TS\ClassSmtp.cs $
//	$Revision: 1.1 $
//	---------------------------------------------------------------------------
using System;
using System.Data;
using System.Configuration;
using System.Net.Mail;
using System.Diagnostics;
using System.Net;

	/// <summary>
	/// Summary description for ClassSmtp
	/// </summary>
public class ClassSmtp
{
	#region Declarations
	private string SendMethod;
	private string SmtpServer;
	private Int32 SmtpPortNo;
	private string SmtpUserName;
	private string SmtpPassword;
	private string m_FromEmail;
	#endregion

	public ClassSmtp()
	{
		this.SendMethod = AttributeLoad("SendMethod", "");
		this.SmtpServer = AttributeLoad("SmtpServer", "");
		Int32.TryParse(AttributeLoad("SmtpPortNo", "25"), out this.SmtpPortNo);
		this.SmtpUserName = AttributeLoad("SmtpUserName", "");
		this.SmtpPassword = AttributeLoad("SmtpPassword", "");
		this.m_FromEmail = AttributeLoad("FromEmail", "");
	}

	private string AttributeLoad(string AttrName, string DefaultValue)
	{
		string RetVal = DefaultValue;

		ClassAttribute oAttr = new ClassAttribute();

		if (oAttr.LoadByName(AttrName) > 0)
			RetVal = oAttr.AttributeValue;

		return RetVal;
	}

	public Boolean SendEmail(string ToEmail, string Subject, string MsgBody, Boolean bHtml)
	{
		Boolean bSuccess = false;

		if (this.SendMethod == "CDOSYS")
		{
			//	Send email via CDOSYS. This is handled by the database.

			bSuccess = Db.SendEmail(ToEmail, Subject, MsgBody, bHtml);
		}
		else
		{
			//	Send email via Net.Mail. This is handled by this class.

			bSuccess = this.SendEmailViaNetMail(ToEmail, Subject, MsgBody, bHtml);
		}

		return bSuccess;
	}

	private Boolean SendEmailViaNetMail(string ToEmail, string Subject, string MsgBody, Boolean bHtml)
	{
		Boolean bRetVal = true;

		try
		{
			MailMessage oMail = new MailMessage();

			oMail.From = new MailAddress(this.m_FromEmail);
			oMail.To.Add(ToEmail);
			oMail.Subject = Subject;
			oMail.Body = MsgBody;
			oMail.IsBodyHtml = bHtml;

			SmtpClient oSmtp = new SmtpClient(SmtpServer, SmtpPortNo);

			//	Authenticate with mail server.

			oSmtp.Credentials = new NetworkCredential(SmtpUserName, SmtpPassword);

			oSmtp.Send(oMail);
		}

		catch (Exception ex)
		{
			Log.LogMsg(ex.Message);
			bRetVal = false;
		}

		return bRetVal;
	}

	public string FromEmail
	{
		get
		{
			return m_FromEmail;
		}
		set
		{
			m_FromEmail = value;
		}
	}

}
