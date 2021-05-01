using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerTemplateAPI.Commons
{
    public static class CheckData<T>
    {
        public static NotFoundObjectResult ItemNotFound(object Id)
        {
            return new NotFoundObjectResult($"ID of {typeof(T).Name} not found : {Id}");
        }

        public static BadRequestObjectResult ItemIntExists(string field, object Id)
        {
            return new BadRequestObjectResult($"{field} of {typeof(T).Name} already exists: {Id}");
        }

        public static BadRequestObjectResult ItemStringExists(string field, string value)
        {
            return new BadRequestObjectResult($"{field} of {typeof(T).Name} already exists: {value}");
        }
    }
}
