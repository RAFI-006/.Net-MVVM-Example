using System;
using System.Collections.Generic;
using System.Text;

namespace Brainer.Model
{
  public  class GenericResponse<T>
    {
     public   int statusCode { get; set; }
     public T data { get; set; } 
     public bool hasError { get; set; }
     public string errorMessage { get; set; }
    }

  
}
