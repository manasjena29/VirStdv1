using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GroupManager
{
    public static class GroupManagerFunction
    {
        [FunctionName("GroupInfoFunc")]
        [return: ServiceBus("myqueue",Connection ="myConnection")]
        public static async Task<IActionResult> Run([HttpTrigger] dynamic input,ILogger log)
        {
            log.LogInformation($"C# function processed: {input.Text}");
            return new OkObjectResult(input.Text);
        }
        
    }
}
