using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerTemplateAPI.Exceptions
{
    public class ModelStateException : Exception
    {
        public ModelStateDictionary ModelState { get; }

        public ModelStateException(string key, string errorMessage)
        {
            ModelState = new ModelStateDictionary();
            ModelState.AddModelError(key, errorMessage);
        }

        public ModelStateException(ModelStateDictionary modelState)
        {
            ModelState = modelState;
        }
    }
}
