using Palette.Base.Domain;
using Palette.Modules.Palettes.Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palette.Modules.Palettes.Domain.Authors
{
    public class Author : Entity
    {
        public AuthorId AuthorId { get; private set; }
        private string _userName;
        private string _email;
        private DateTime _createdDate;

        public static Author Create(Guid id, string userName, string email)
        {
            return new Author(id, userName, email);
        }

        private Author(Guid id, string userName, string email)
        {
            AuthorId = new AuthorId(id);
            _userName = userName;
            _email = email;
            _createdDate = SystemClock.Now;
        }
    }
}
