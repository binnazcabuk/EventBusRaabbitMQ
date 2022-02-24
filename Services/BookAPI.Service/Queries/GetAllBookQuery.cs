using AutoMapper;
using BookAPI.Service.Dto;
using BookAPI.Service.Models;
using BookAPI.Service.MongoSettings;
using MediatR;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BookAPI.Service.Queries
{
    public class GetAllBookQuery : IRequest<List<Book>>
    {
       
    }
    public class GetAllBookQueryHandler : IRequestHandler<GetAllBookQuery,List<Book>>
    {
        private readonly IMongoCollection<Book> _bookCollection;
        private readonly IMapper _mapper;

        public GetAllBookQueryHandler(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            _mapper=mapper;
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _bookCollection = database.GetCollection<Book>(databaseSettings.BookCollectionName);
        }

        public async Task<List<Book>> Handle(GetAllBookQuery request, CancellationToken cancellationToken)
        {
            var result=await _bookCollection.Find<Book>(x=>true).ToListAsync();
          
            return _mapper.Map<List<Book>>(result);

        }
    }
}
