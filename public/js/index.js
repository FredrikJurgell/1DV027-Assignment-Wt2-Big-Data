import '../socket.io/socket.io.js'

const baseURL = document.querySelector('base').getAttribute('href')

// Create a socket connection using Socket.io.
const socket = window.io({ path: `${baseURL}socket.io` })

socket.on('genreCount', (genreCount) => {
  const ctx = document.getElementById('myChart')
  let data = {
    labels: Object.keys(genreCount.genreCount),
    datasets: [{
      label: 'Number of movies per genre from top 1000 movies and tv shows on IMDB',
      data: Object.values(genreCount.genreCount),
      backgroundColor: 'rgba(54, 162, 235, 0.5)',
      borderColor: 'rgba(54, 162, 235, 1)',
      borderWidth: 1
    }]
  }

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
})
