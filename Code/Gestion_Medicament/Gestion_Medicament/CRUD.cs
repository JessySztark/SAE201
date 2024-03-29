using System;
using System.Collections.Generic;

namespace Gestion_Medicament
{
    public interface CRUD<T>
    {
        void Create();
        void Read();
        void Update(int id, String nom);
        void Delete(int id);
        List<T> FindAll();
        List<T> FindBySelection(ref String criteres);
    }
}