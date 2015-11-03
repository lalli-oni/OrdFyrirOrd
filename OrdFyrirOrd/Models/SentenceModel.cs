using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdFyrirOrd.Models
{
    class SentenceModel
    {
        #region Fields
        #region Variables
        private Source _sourceType;
        private List<string> _sentences;
        private int _sourceSize;

        #endregion
        #region Properties
        public Source SourceType
        {
            get { return _sourceType; }
            set { _sourceType = value; }
        }
        public int SourceSize
        {
            get { return _sourceSize; }
            set { _sourceSize = value; }
        }
        public List<string> Sentences
        {
            get { return _sentences; }
            set { _sentences = value; }
        }
        #endregion
        #endregion

        public SentenceModel(SourceModel source)
        {
            _sourceType = source.SourceType;
            _sourceSize = source.SourceSize;
            SentenceHandler seh = new SentenceHandler();
            Sentences = seh.SplitToSentences(source.SourceData);
        }
    }
}
