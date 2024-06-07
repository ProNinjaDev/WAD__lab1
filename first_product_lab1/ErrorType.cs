using first_product_lab1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace first_product_lab1
{
    public enum ErrorType
    {
        InvalidInput,
        BirthdayBeyond,
        IncorrectLength,
        IncorrectPassword
    }
}

class CustomError : Exception
{
    public ErrorType Error {  get; }
    public string ErrorDescription { get; }
    public CustomError(ErrorType error, string errorDescriprion)
    {
        Error = error;
        ErrorDescription = errorDescriprion;

    }
}

class ErrorHandler
{
    public static void HandleError(CustomError error)
    {
        switch(error.Error) 
        {
            case ErrorType.InvalidInput:
                MessageBox.Show(error.ErrorDescription, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                break;

            case ErrorType.BirthdayBeyond:
                MessageBox.Show(error.ErrorDescription, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                break;

            case ErrorType.IncorrectLength:
                MessageBox.Show(error.ErrorDescription, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                break;

            case ErrorType.IncorrectPassword:
                MessageBox.Show(error.ErrorDescription, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                break;

            default:
                MessageBox.Show("Неизвестная ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                break;
        }
    }
}