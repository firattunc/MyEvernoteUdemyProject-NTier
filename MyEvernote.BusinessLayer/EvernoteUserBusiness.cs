using MyEvernote.DataAccsessLayer.EF;
using MyEvernote.Entities;
using MyEvernote.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEvernote.BusinessLayer
{
    public class EvernoteUserBusiness
    {
        private Repository<EvernoteUser> repo_user = new Repository<EvernoteUser>();

        public BusinessLayerResult<EvernoteUser> RegisterUser(RegisterViewModel model)
        {
            EvernoteUser user = repo_user.Find(x => x.UserName == model.kullaniciAdi || x.Email == model.ePosta);
            BusinessLayerResult<EvernoteUser> layerResult=new BusinessLayerResult<EvernoteUser>();
            if (user!=null)
            {
                if (model.kullaniciAdi==user.UserName)
                {
                    layerResult.Errors.Add("Kullanıcı adı kayıtlı.");

                }
                if (model.ePosta==user.Email)
                {
                    layerResult.Errors.Add("E-posta kayıtlı.");
                }
                
            }
            else
            {
                int dbResult = repo_user.Insert(user);
                if (dbResult>0)
                {
                    //TODO : Aktivasyon emaili yollanacak
                }

            }

            return layerResult;
        }
    }
}
