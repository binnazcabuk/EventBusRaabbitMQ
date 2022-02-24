using BorrowAPI.Service.Context;
using EventBus.Base.İnterfaces;
using Microsoft.EntityFrameworkCore;
using Shared.Libary;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BorrowAPI.Service.EventHandler
{
    public class BookNameChangesEventHandler : IIntegrationEventHandler<BookNameChangesEvent>
    {
        private readonly BorrowDbContext _context;

        public BookNameChangesEventHandler(BorrowDbContext context)
        {
            _context=context;
        }

        public async Task Handle(BookNameChangesEvent @event)
        {
            var result = await _context.Borrows.Where(x => x.bookId==@event.BookId).ToListAsync();

            foreach (var item in result)
            {
                item.bookName=@event.Name;

             }       
            _context.Borrows.UpdateRange(result);
            await _context.SaveChangesAsync();
         
        }
    }

}
