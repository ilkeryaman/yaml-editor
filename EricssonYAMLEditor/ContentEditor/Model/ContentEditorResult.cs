using EricssonYAMLEditor.Exception.Model;

namespace EricssonYAMLEditor.ContentEditor.Model
{
    class ContentEditorResult
    {
        private bool _isSucceded;
        private ImplementationException _exception;

        public ContentEditorResult()
        {
            _isSucceded = true;
            _exception = null;
        }

        public bool IsSucceded
        {
            get { return _isSucceded; }
        }

        public ImplementationException Exception
        {
            get { return _exception; }
        }

        public ContentEditorResult SetException(string message)
        {
            _isSucceded = false;
            _exception = new ImplementationException(message);
            return this;
        }
    }
}
