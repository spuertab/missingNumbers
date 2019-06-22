
namespace PuntosColombia.MissingNumbers.Application.Services
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface INumberService
    {
        string MissingNumbers(string astr, string bstr);
    }
}
