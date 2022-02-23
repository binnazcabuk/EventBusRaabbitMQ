using AutoMapper;
using BookAPI.Service.Dto;
using BookAPI.Service.Models;
using BookAPI.Service.MongoSettings;
using MediatR;
using MongoDB.Driver;
using System.Threading;
using System.Threading.Tasks;

namespace BookAPI.Service.Commands
{

    public class CreateBookCommand : IRequest<BookCreateDto>
    {
        public string name { get; set; }
        public string writerName { get; set; }
        public string publisher { get; set; }
        public string years { get; set; }
    }

    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand,BookCreateDto>
    {
        private readonly IMongoCollection<Book> _bookCollection;
        private readonly IMapper _mapper;
        public CreateBookCommandHandler(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _bookCollection = database.GetCollection<Book>(databaseSettings.BookCollectionName);
            _mapper = mapper;
        }

        public async Task<BookCreateDto> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = _mapper.Map<Book>(request);

            await _bookCollection.InsertOneAsync(book);

            return _mapper.Map<BookCreateDto>(book);
        }
    }
}
