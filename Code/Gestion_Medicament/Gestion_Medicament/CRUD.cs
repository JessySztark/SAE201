using System;
using System.Collections.Generic;

public interface CRUD<T>
{
    void Create();
    void Read();
    void Update();
    void Delete();
    List<T> FindAll();
	List<T> FindBySelection(ref String criteres);
}
