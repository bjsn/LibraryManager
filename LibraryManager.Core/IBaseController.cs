namespace LibraryManager.Core
{
    using LibraryManager.Models;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    public interface IBaseController
    {
        void Delete(string identifier);
        List<BaseEntity> Get();
        ProposalContent Get(string identifier);
        List<BaseEntity> GetByKeyWord(string keyWord);
        List<BaseEntity> GetFiltered(bool bvalue = false, string value = "", string keyWord = "");
        void Save(BaseEntity entity);
        void Update(BaseEntity entity);
    }
}

