using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Domain.Payment.Model;

namespace VirtoCommerce.CoreModule.Data.Payment
{
    public class DefaultManualPaymentMethod : PaymentMethod
    {
        public DefaultManualPaymentMethod() : base("DefaultManualPaymentMethod")
        {
        }


        public override PaymentMethodType PaymentMethodType
        {
            get { return Domain.Payment.Model.PaymentMethodType.Unknown; }
        }

        public override PaymentMethodGroupType PaymentMethodGroupType
        {
            get { return Domain.Payment.Model.PaymentMethodGroupType.Manual; }
        }

        public override ProcessPaymentResult ProcessPayment(ProcessPaymentEvaluationContext context)
        {
            //The PaymentStatus doesn't copied to Payment.Status during save so we need set it for backward compatibility
            context.Payment.PaymentStatus = PaymentStatus.Paid;
            context.Payment.Status = PaymentStatus.Paid.ToString();
            context.Payment.OuterId = context.Payment.Number;
            context.Payment.CapturedDate = DateTime.UtcNow;
            context.Payment.IsApproved = true;
            return new ProcessPaymentResult { IsSuccess = true, NewPaymentStatus = PaymentStatus.Paid };
        }

        public override PostProcessPaymentResult PostProcessPayment(PostProcessPaymentEvaluationContext context)
        {
            throw new NotImplementedException();
        }

        public override VoidProcessPaymentResult VoidProcessPayment(VoidProcessPaymentEvaluationContext context)
        {
            context.Payment.IsApproved = false;
            //The PaymentStatus doesn't copied to Payment.Status during save so we need set it for backward compatibility
            context.Payment.PaymentStatus = PaymentStatus.Voided;
            context.Payment.Status = PaymentStatus.Voided.ToString();
            context.Payment.VoidedDate = DateTime.UtcNow;
            context.Payment.IsCancelled = true;
            context.Payment.CancelledDate = DateTime.UtcNow;
            return new VoidProcessPaymentResult { IsSuccess = true, NewPaymentStatus = PaymentStatus.Voided };
        }

        public override CaptureProcessPaymentResult CaptureProcessPayment(CaptureProcessPaymentEvaluationContext context)
        {
            context.Payment.IsApproved = true;
            //The PaymentStatus doesn't copied to Payment.Status during save so we need set it for backward compatibility
            context.Payment.PaymentStatus = PaymentStatus.Paid;
            context.Payment.Status = PaymentStatus.Paid.ToString();
            context.Payment.VoidedDate = DateTime.UtcNow;
            return new CaptureProcessPaymentResult { IsSuccess = true, NewPaymentStatus = PaymentStatus.Paid };
        }

        public override RefundProcessPaymentResult RefundProcessPayment(RefundProcessPaymentEvaluationContext context)
        {
            throw new NotImplementedException();
        }

        public override ValidatePostProcessRequestResult ValidatePostProcessRequest(System.Collections.Specialized.NameValueCollection queryString)
        {
            return new ValidatePostProcessRequestResult { IsSuccess = false };
        }
    }
}
