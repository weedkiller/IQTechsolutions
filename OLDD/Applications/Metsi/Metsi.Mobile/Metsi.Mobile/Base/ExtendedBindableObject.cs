using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace Metsi.Mobile.Base
{
    /// <summary>
    /// The base extended bindable object that impliments property changed notification
    /// </summary>
    public abstract class ExtendedBindableObject : BindableObject
    {
        /// <summary>
        /// Raises the property changed event
        /// </summary>
        /// <typeparam name="T">The type of property that the event is being raised on</typeparam>
        /// <param name="property">The property function</param>
        public void RaisePropertyChanged<T>(Expression<Func<T>> property)
        {
            var name = GetMemberInfo(property).Name;
            OnPropertyChanged(name);
        }

        /// <summary>
        /// Get the information of the specific property
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        private MemberInfo GetMemberInfo(Expression expression)
        {
            MemberExpression operand;
            LambdaExpression lambdaExpression = (LambdaExpression)expression;
            if (lambdaExpression.Body as UnaryExpression != null)
            {
                UnaryExpression body = (UnaryExpression)lambdaExpression.Body;
                operand = (MemberExpression)body.Operand;
            }
            else
            {
                operand = (MemberExpression)lambdaExpression.Body;
            }
            return operand.Member;
        }
    }
}
