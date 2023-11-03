namespace WordFrequency
{
    public class WordCount
    {
        private string word;
        private int count;

        public WordCount(string word, int count)
        {
            this.word = word;
            this.count = count;
        }

        public string Word
        {
            get { return this.word; }
        }

        public int Count
        {
            get { return this.count; }
        }
    }
}
