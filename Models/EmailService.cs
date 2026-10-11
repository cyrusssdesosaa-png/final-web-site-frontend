using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace WallyWombatsPublic_MVC.Models;

public class EmailService
{
	private readonly IConfiguration _configuration;
	private readonly ILogger<EmailService> _logger;

	public EmailService(IConfiguration configuration, ILogger<EmailService> logger)
	{
		_configuration = configuration;
		_logger = logger;
	}

	public async Task<bool> SendEmailAsync(string message, string? replyTo = null)
	{
		var smtpServer = _configuration["SmtpSettings:Server"];
		var smtpPassword = _configuration["SmtpSettings:Password"];
		var smtpUsername = _configuration["SmtpSettings:Username"];
		var senderName = _configuration["SmtpSettings:SenderName"];
		var senderEmail = _configuration["SmtpSettings:SenderEmail"];
		if (string.IsNullOrWhiteSpace(smtpServer) || string.IsNullOrWhiteSpace(smtpPassword) || !int.TryParse(_configuration["SmtpSettings:Port"], out var smtpPort))
		{
			_logger.LogWarning("Inquiry email was not sent. The mailbox password is not set.");
			return false;
		}

		var emailMessage = new MimeMessage
		{
			Subject = "Wally Wombats Inquiry",
			Body = new TextPart("html") { Text = message }
		};
		var inbox = string.IsNullOrWhiteSpace(senderEmail) ? smtpUsername : senderEmail;
		emailMessage.From.Add(new MailboxAddress(senderName ?? "Wally Wombats", inbox));
		emailMessage.To.Add(new MailboxAddress("Wally Wombats", inbox));
		if (!string.IsNullOrWhiteSpace(replyTo))
		{
			try
			{
				emailMessage.ReplyTo.Add(MailboxAddress.Parse(replyTo.Trim()));
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex, "Inquiry reply address was skipped.");
			}
		}

		try
		{
			using var client = new SmtpClient();
			await client.ConnectAsync(smtpServer, smtpPort, SecureSocketOptions.StartTls);
			await client.AuthenticateAsync(smtpUsername, smtpPassword);
			await client.SendAsync(emailMessage);
			await client.DisconnectAsync(quit: true);
			return true;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex, "Inquiry email to {Inbox} did not send.", senderEmail ?? smtpUsername);
			return false;
		}
	}
}
