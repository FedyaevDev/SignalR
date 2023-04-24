using Microsoft.AspNetCore.SignalR.Client;
using SignalRModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp49.Services
{
    public class ChatService
    {
        private readonly HubConnection _hubConnection;

        public event Action<Message> MessageReceivedEvent;

        public ChatService(HubConnection hubConnection)
        {
            _hubConnection = hubConnection;

            _hubConnection.On<Message>("ReceiveMessage", message => MessageReceivedEvent?.Invoke(message));

        }

        public async Task Connect()
        {
            await _hubConnection.StartAsync();
        }

        public async Task SendMessage(Message message)
        {
            await _hubConnection.SendAsync("SendMessage", message);
        }
    }
}
