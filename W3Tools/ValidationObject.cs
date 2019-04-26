using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace W3Tools
{
    public abstract class ValidationObject : ObservableObject, INotifyDataErrorInfo
    {
        private Dictionary<string, IList<string>> _errors;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public bool HasErrors
        {
            get
            {
                return _errors.Count > 0;
            }
        }

        public ValidationObject()
        {
            _errors = new Dictionary<string, IList<string>>();
        }

        public IEnumerable GetErrors(string propertyName)
        {
            if(_errors.TryGetValue(propertyName, out var errors))
            {
                return errors;
            }
            return null;
        }

        protected virtual void AddError(string error, [CallerMemberName] string propertyName = null)
        {
            if(!_errors.ContainsKey(propertyName))
            {
                _errors.Add(propertyName, new List<string>());
            }
            if(!_errors[propertyName].Contains(error))
            {
                _errors[propertyName].Add(error);
                InvokeErrorsChanged(propertyName);
            }
        }

        protected virtual void RemoveErrors([CallerMemberName] string propertyName = null)
        {
            if(_errors.ContainsKey(propertyName))
            {
                _errors.Remove(propertyName);
            }
        }

        protected virtual void InvokeErrorsChanged([CallerMemberName] string propertyName = null)
        {
            var errorsChanged = ErrorsChanged;
            errorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        IEnumerable INotifyDataErrorInfo.GetErrors(string propertyName)
        {
            throw new NotImplementedException();
        }
    }
}
