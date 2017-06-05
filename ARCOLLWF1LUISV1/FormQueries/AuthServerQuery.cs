
using Microsoft.Bot.Builder.FormFlow;
using System;

namespace ARCOLLWF1LUISV1.FormQueries
{

    [Template(TemplateUsage.NotUnderstood, "I do not understand \"{0}\".", "Try again, I don't get \"{0}\".")]
    [Serializable]
    public class AuthServerQuery
    {

        [Optional]
        [Describe("Server URL")]
        public string ServerURL { get; set; }

        [Optional]
        [Describe("Company")]
        public string Company { get; set; }

        [Optional]
        [Describe("Branch")]
        public string Branch { get; set; }


    }
}
 