using EricssonYAMLEditor.Exception.Model;
using System;

namespace EricssonYAMLEditor.ContentEditor.Model
{
    class ContentEditorResult
    {
        private bool _isSucceded;
        private ApplicationException _exception;

        public ContentEditorResult()
        {
            _isSucceded = true;
            _exception = null;
        }

        public bool IsSucceded
        {
            get { return _isSucceded; }
        }

        public ApplicationException Exception
        {
            get { return _exception; }
        }

        public ContentEditorResult SetException(ApplicationException exception)
        {
            _isSucceded = false;
            _exception = exception;
            return this;
        }
    }
}
