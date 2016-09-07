
namespace LotterySpinner
{
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;

    class MainViewModel: INotifyPropertyChanged
    {
        private int lotto1;

        private int lotto2;

        private int lotto3;

        private int lotto4;

        private int lotto5;

        private int lotto6;

        private int euro1;

        private int euro2;

        private int euro3;

        private int euro4;

        private int euro5;

        private int euroStar1;

        private int euroStar2;

        public int Lotto1
        {
            get
            {
                return this.lotto1;
            }
            set
            {
                this.lotto1 = value;
                this.OnPropertyChanged();
            }
        }

        public int Lotto2
        {
            get
            {
                return this.lotto2;
            }
            set
            {
                this.lotto2 = value;
                this.OnPropertyChanged();
            }
        }

        public int Lotto3
        {
            get
            {
                return this.lotto3;
            }
            set
            {
                this.lotto3 = value;
                this.OnPropertyChanged();
            }
        }

        public int Lotto4
        {
            get
            {
                return this.lotto4;
            }
            set
            {
                this.lotto4 = value;
                this.OnPropertyChanged();
            }
        }

        public int Lotto5
        {
            get
            {
                return this.lotto5;
            }
            set
            {
                this.lotto5 = value;
                this.OnPropertyChanged();
            }
        }

        public int Lotto6
        {
            get
            {
                return this.lotto6;
            }
            set
            {
                this.lotto6 = value;
                this.OnPropertyChanged();
            }
        }

        public int Euro1
        {
            get
            {
                return this.euro1;
            }
            set
            {
                this.euro1 = value;
                this.OnPropertyChanged();
            }
        }

        public int Euro2
        {
            get
            {
                return this.euro2;
            }
            set
            {
                this.euro2 = value;
                this.OnPropertyChanged();
            }
        }

        public int Euro3
        {
            get
            {
                return this.euro3;
            }
            set
            {
                this.euro3 = value;
                this.OnPropertyChanged();
            }
        }

        public int Euro4
        {
            get
            {
                return this.euro4;
            }
            set
            {
                this.euro4 = value;
                this.OnPropertyChanged();
            }
        }

        public int Euro5
        {
            get
            {
                return this.euro5;
            }
            set
            {
                this.euro5 = value;
                this.OnPropertyChanged();
            }
        }

        public int EuroStar1
        {
            get
            {
                return this.euroStar1;
            }
            set
            {
                this.euroStar1 = value;
                this.OnPropertyChanged();
            }
        }

        public int EuroStar2
        {
            get
            {
                return this.euroStar2;
            }
            set
            {
                this.euroStar2 = value;
                this.OnPropertyChanged();
            }
        }

        public ICommand SpinCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            SpinCommand = new RelayCommand<object>(Spin);
        }

        private void Spin(object obj)
        {
            var lottoNumbers = new int[6];

            for (var i = 0; i < 6; i++)
            {
                lottoNumbers[i] = LottrySpinner.GetLottoNumber(lottoNumbers);
            }

            var orderedLottoNumbers = lottoNumbers.OrderBy(i => i).ToArray();

            Lotto1 = orderedLottoNumbers.First();
            Lotto2 = orderedLottoNumbers.Skip(1).First();
            Lotto3 = orderedLottoNumbers.Skip(2).First();
            Lotto4 = orderedLottoNumbers.Skip(3).First();
            Lotto5 = orderedLottoNumbers.Skip(4).First();
            Lotto6 = orderedLottoNumbers.Skip(5).First();

            var euroNumbers = new int[5];

            for (var i = 0; i < 5; i++)
            {
                euroNumbers[i] = LottrySpinner.GetEuroNumber(euroNumbers);
            }

            var euroStars = new int[2];

            for (var i = 0; i < 2; i++)
            {
                euroStars[i] = LottrySpinner.GetEuroLuckStar(euroNumbers);
            }

            var orderedEuroNumbers = euroNumbers.OrderBy(i => i).ToArray();
            var orderedEuroStars = euroStars.OrderBy(i => i).ToArray();

            Euro1 = orderedLottoNumbers.First();
            Euro2 = orderedEuroNumbers.Skip(1).First();
            Euro3 = orderedEuroNumbers.Skip(2).First();
            Euro4 = orderedEuroNumbers.Skip(3).First();
            Euro5 = orderedEuroNumbers.Skip(4).First();
            EuroStar1 = orderedEuroStars.First();
            EuroStar2 = orderedEuroStars.Skip(1).First();
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
