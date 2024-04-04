using Azure;
using Chat5.CQRS.Partial.Queries;
using Chat5.Entities;
using Chat5.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Chat5
{
	public class MessageHub :Hub
	{

		public async Task MessageInformationBold( GetMessageQuery getMessage)
		{
			await Clients.All.SendAsync( "BoldConversationName", getMessage );
		}


		public async Task SendMessage(MessageWithCurrentLogUser message )
		{
			await Clients.All.SendAsync("ReceivedMessage", message);
		}
    }
}


