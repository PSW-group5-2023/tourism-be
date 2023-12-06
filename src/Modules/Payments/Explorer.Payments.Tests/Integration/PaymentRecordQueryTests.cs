using Explorer.API.Controllers.Shopping;
using Explorer.Payments.API.Public;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Payments.Tests.Integration
{
    public class PaymentRecordQueryTests : BasePaymentsIntegrationTest
    {
        public PaymentRecordQueryTests(PaymentsTestFactory factory) : base(factory)
        {
        }

        private static PaymentRecordController CreateController(IServiceScope scope)
        {
            return new PaymentRecordController(scope.ServiceProvider.GetRequiredService<IPaymentRecordService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }
    }
}
