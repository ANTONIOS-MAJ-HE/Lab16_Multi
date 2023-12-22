using Lab12TODOLIST.Models;
using Lab12TODOLIST.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lab12TODOLIST.ViewModels
{
    public class CursoViewModel : BaseViewModel
    {
        private readonly ApiService apiService = new ApiService();
        public ObservableCollection<Curso> Cursos { get; } = new ObservableCollection<Curso>();

        public ICommand LoadCursosCommand { get; }
        public ICommand AddCursoCommand { get; }

        public Curso NewCurso { get; set; } = new Curso();

        public CursoViewModel()
        {
            LoadCursosCommand = new Command(async () => await LoadCursosAsync());
            AddCursoCommand = new Command(async () => await AddCursoAsync());
            LoadCursosCommand.Execute(null);
        }

        private async Task LoadCursosAsync()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            var cursosList = await apiService.GetCursosAsync();
            Cursos.Clear();
            foreach (var curso in cursosList)
            {
                Cursos.Add(curso);
            }
            IsBusy = false;
        }

        private async Task AddCursoAsync()
        {
            if (IsBusy || NewCurso == null)
                return;

            IsBusy = true;
            var success = await apiService.AddCursoAsync(NewCurso);
            if (success)
            {
                LoadCursosCommand.Execute(null);
                NewCurso = new Curso(); // Reset the form
                OnPropertyChanged(nameof(NewCurso));
            }
            IsBusy = false;
        }
    }
}
