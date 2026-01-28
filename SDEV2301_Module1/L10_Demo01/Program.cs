using L10_Demo01;

//EmailSender sender = new EmailSender();
//sender.Send("Hello, this is a test email message.");

IMessageSender sender = new EmailSender();
sender.Send("Hello, this is a test email message.");
sender = new SmsSender();
sender.Send("Hello, this is a test SMS message.");