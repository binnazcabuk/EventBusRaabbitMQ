using AutoMapper;

using BookAPI.Service.Models;
using BookAPI.Service.MongoSettings;
using EventBus.Base.İnterfaces;
using MediatR;
using MongoDB.Driver;
using Shared.Libary;
using System.Threading;
using System.Threading.Tasks;

namespace BookAPI.Service.Commands
{
    public class UpdateBookCommand : IRequest<Book>
    {
        public string id { get; set; }
        public string name { get; set; }
        public string writerName { get; set; }
        public string publisher { get; set; }
        public string years { get; set; }
    }

    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Book>
    {
        private readonly IMongoCollection<Book> _bookCollection;
        private readonly IMapper _mapper;
        private readonly IEventBus _eventBus;
        public UpdateBookCommandHandler(IMapper mapper, IDatabaseSettings databaseSettings,IEventBus eventBus)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _bookCollection = database.GetCollection<Book>(databaseSettings.BookCollectionName);
            _eventBus=eventBus;
            _mapper = mapper;
        }
        public async Task<Book> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var updateBook = _mapper.Map<Book>(request);
            var result = await _bookCollection.FindOneAndReplaceAsync(x => x.id == request.id, updateBook);

            ///event gönderme
            var book = new BookNameChangesEvent(request.id, request.name);
            _eventBus.Publish(book);

            return result;
        }
    }



}

