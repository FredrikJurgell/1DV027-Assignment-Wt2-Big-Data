const genreCount = JSON.parse(document.getElementById('data').textContent)

let data = {
  labels: Object.keys(genreCount),
  datasets: [{
    label: 'Number of movies per genre from top 1000 movies and tv shows on IMDB',
    data: Object.values(genreCount),
    backgroundColor: 'rgba(54, 162, 235, 0.5)',
    borderColor: 'rgba(54, 162, 235, 1)',
    borderWidth: 1
  }]
}

const ctx = document.getElementById('myChart')

new Chart(ctx, {
  type: 'bar',
  data: data,
  options: {
    scales: {
      y: {
        beginAtZero: true
      }
    }
  }
})
