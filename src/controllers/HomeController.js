/**
 * Module for the HomeController.
 *
 * @author Fredrik Jurgell
 * @version 1.0.0
 */

import https from 'https'
import fetch from 'node-fetch'

/**
 * Controller for the home page.
 */
export class HomeController {
  /**
   * Renders the home page with genre statistics.
   *
   * @param {object} req - The HTTP request.
   * @param {object} res - The HTTP response.
   * @param {Function} next - The next middleware function.
   */
  async index (req, res, next) {
    try {
      const username = 'elastic'
      const password = process.env.ELASTIC_PASSWORD
      const query = {
        size: 1000,
        aggs: {
          genres: {
            terms: {
              field: 'genre.keyword'
            }
          }
        }
      }

      const url = 'https://localhost:9200/imdbdata/_search'
      const response = await fetch(url, {
        method: 'POST',
        body: JSON.stringify(query),
        headers: {
          'Content-Type': 'application/json',
          Authorization: `Basic ${Buffer.from(`${username}:${password}`).toString('base64')}`
        },
        agent: new https.Agent({ rejectUnauthorized: false })
      })

      const data = await response.json()
      const movies = data.hits.hits
      const genreCount = countGenres(movies)

      // Socket.io: Send the created issue to all subscribers.
      res.io.emit('genreCount', {
        genreCount
      })

      res.render('home/index')
    } catch (error) {
      next(error)
    }
  }
}

/**
 * Counts the number of movies per genre.
 *
 * @param {Array} movies - The array of movies.
 * @returns {object} An object containing the count of movies per genre.
 */
function countGenres (movies) {
  const genreCount = {}
  // Loop through every movie
  for (let i = 0; i < movies.length; i++) {
    // Split every genre-string into a array of gengre
    let genres = movies[i]._source.genre.split(', ')
    // Loop through every genre
    for (let j = 0; j < genres.length; j++) {
      if (genreCount[genres[j]]) {
        genreCount[genres[j]]++
      } else {
        genreCount[genres[j]] = 1
      }
    }
  }

  return genreCount
}
