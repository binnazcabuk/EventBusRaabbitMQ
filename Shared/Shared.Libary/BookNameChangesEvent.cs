using EventBus.Base.Events;
using System;

namespace Shared.Libary
{
    public class BookNameChangesEvent : IntegrationEvent
    {

        public string BookId { get; }
        public string Name { get; }

        public BookNameChangesEvent(string bookId, string name)
        {
            BookId=bookId;
            Name=name;
        }
    }
}
