using FluentValidation;
using QPH_ParamsChannelsEnterprise.Core.DTOs;
using QPH_ParamsChannelsEnterprise.Core.Enumerators;
using System;

namespace QPH_ParamsChannelsEnterprise.Core.Validations
{
    public class ChannelValidations : AbstractValidator<ChannelDTO>
    {
        public ChannelValidations()
        {
            RuleFor(t => t.Fecha)
                .Equal(DateTime.Today).WithMessage("No se permite otra fecha diferente de hoy.")
                .NotNull().WithMessage("La fecha es requerida.");

            RuleFor(t => t.Segmento)
                .MaximumLength(100).WithMessage("El segmento no puede tener más de 100 caracteres.")
                .NotNull().WithMessage("El segmento es requerido");

            RuleFor(t => t.PuntoEmision)
                .MaximumLength(100).WithMessage("El punto de emisión no puede tener más de 100 caracteres.")
                .NotNull().WithMessage("El punto de emisión es requerido.");

            RuleFor(t => t.CodeCreditCard)
                .NotNull().WithMessage("El código de tarjeta de crédito es requerido.").When(t => t.PaymentReceivedRequired == StatusSI_NOEnum.SI.ToString());

            RuleFor(t => t.IVACode)
                .MaximumLength(50).WithMessage("El código de IVA no puede tener más de 50 caracteres.")
                .NotNull().WithMessage("El código de IVA de emisión es requerido.");

            RuleFor(t => t.CodigoProducto)
                .MaximumLength(10).WithMessage("El código de producto no puede tener más de 10 caracteres.")
                .NotNull().WithMessage("El código de producto de emisión es requerido.");

            RuleFor(t => t.NombreProducto)
               .MaximumLength(300).WithMessage("El nombre de producto no puede tener más de 300 caracteres.")
               .NotNull().WithMessage("El nombre de producto de emisión es requerido.");

            RuleFor(t => t.CuentaContable)
               .MaximumLength(50).WithMessage("La cuenta contable no puede tener más de 50 caracteres.")
               .NotNull().WithMessage("La cuenta contable es requerida.");

            RuleFor(t => t.TipoFormaPago)
               .MaximumLength(10).WithMessage("El tipo de forma de pago no puede tener más de 10 caracteres.")
               .NotNull().WithMessage("El tipo de forma de pago es requerido.");

            RuleFor(t => t.EnlaceInvoice)
               .MaximumLength(8000)
               .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _)).When(x => !string.IsNullOrEmpty(x.EnlaceInvoice))
               .NotNull().WithMessage("El enlace de la factura es requerido.");

            RuleFor(t => t.EnlaceCreditNote)
               .MaximumLength(8000)
               .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _)).When(x => !string.IsNullOrEmpty(x.EnlaceInvoice))
               .NotNull().WithMessage("El enlace de la nota de crédito es requerido.");

            RuleFor(t => t.EnlaceCotization)
               .MaximumLength(8000)
               .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _)).When(x => !string.IsNullOrEmpty(x.EnlaceInvoice))
               .NotNull().WithMessage("El enlace de la cotización es requerido.");

            RuleFor(t => t.Code)
               .MaximumLength(150).WithMessage("El código no puede tener más de 150 caracteres.")
               .NotNull().WithMessage("El código es requerido.");

            RuleFor(t => t.Description)
               .MaximumLength(500).WithMessage("La descripción no puede tener más de 500 caracteres.")
               .NotNull().WithMessage("La descripción es requerida.");

            RuleFor(t => t.AuthorizationNumber)
               .MaximumLength(20).WithMessage("El número de autorización no puede tener más de 20 caracteres.")
               .NotNull().WithMessage("El número de autorización es requerido.");

            RuleFor(t => t.ProductItemGroupCode)
               .NotNull().WithMessage("El código del producto de item es requerido.");

            RuleFor(t => t.Declarable)
               .NotNull().WithMessage("El campo Declarable es requerido.")
                .MaximumLength(20)
                .WithMessage("El campo Declarable tiene formato incorrecto.")
                .IsEnumName(typeof(StatusSI_NOEnum), caseSensitive: false)
                .WithMessage("El campo Declarable tiene formato incorrecto.");

            RuleFor(t => t.IdentificatorChannelSAP)
               .NotNull().WithMessage("El identificador de canal SAP es requerido.");

            RuleFor(t => t.PaymentReceivedRequired)
               .NotNull().WithMessage("El campo Pago Recibido Requerido es requerido.")
                .MaximumLength(20)
                .WithMessage("El campo Pago Recibido Requerido tiene formato incorrecto.")
                .IsEnumName(typeof(StatusSI_NOEnum), caseSensitive: false)
                .WithMessage("El campo Pago Recibido Requerido tiene formato incorrecto.");

            RuleFor(t => t.LimitStartDateTransactions)
               .NotNull().WithMessage("La fecha de inicio límite de transacción es requerida.");

            RuleFor(t => t.LimitFinishDateTransactions)
               .NotNull().WithMessage("La fecha fin límite de transacción es requerida.");

            RuleFor(t => t.BalanceAccount)
                .MaximumLength(100).WithMessage("La cuenta de balance no puede tener más de 100 caracteres.")
                .NotNull().WithMessage("La cuenta de balance es requerida.");

            RuleFor(t => t.EnterpriseID)
               .NotNull().WithMessage("La empresa es requerida es requerida.");

            RuleFor(t => t.FinancialSizingID)
               .NotNull().WithMessage("El dimensionamiento financiero es requerido.");

            RuleFor(t => t.CodigoMotivoNotaCredito)
               .NotNull().WithMessage("El código de motivo de la nota de crédito es requerido.");

            RuleFor(t => t.Status)
               .NotNull().WithMessage("El estado es requerido.")
                .MaximumLength(20)
                .WithMessage("El estado tiene formato incorrecto.")
                .IsEnumName(typeof(StatusSI_NOEnum), caseSensitive: false)
                .WithMessage("El estado tiene formato incorrecto.");
        }
    }
}
