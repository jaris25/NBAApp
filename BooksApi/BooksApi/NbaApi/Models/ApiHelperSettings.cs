using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NbaApi.Models
{
    public class ApiHelperSettings:IApiHelperSettings
    {
        public string Uri { get; set; }
    }
    public interface IApiHelperSettings
    {
        public string Uri { get; set; }
    }
}
