using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyEvernote.DataAccsessLayer.EF;
using MyEvernote.Entities;

namespace MyEvernote.BusinessLayer
{
    public class NoteBusiness
    {
        private Repository<Note> repo_note = new Repository<Note>();

        public List<Note> SelectAllNotes()
        {
            return repo_note.List();
        }
        public IQueryable<Note> SelectAllNotesQueryable()
        {
            return repo_note.ListQueryable();
        }
        public List<Note> SelectNotesByCategoryId(int categoryId)
        {
            return repo_note.List(x => x.KategoriId == categoryId);
        }
    }
}
