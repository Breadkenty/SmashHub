// Returns an object that can be included in `fetch`
// headers to include the required bearer token
// for authentication
//
// Example usage:
//
// fetch('/api/Thing', {
//    method: 'POST',
//    headers: { 'content-type': 'application/json', ...authHeader() },
//    body: JSON.stringify(thing)
// })
//
export const authHeader = () => {
  const auth = authFromStorage()

  return auth.token
    ? {
        Authorization: `Bearer ${auth.token}`,
      }
    : {}
}

// Save the authentication received from the API
//
// This method stores the authentication data as
// a JSON string in local storage. Local storage
// requires everything to be in a string.
//
// This is typically called from a login component
//
export const recordAuthentication = auth => {
  localStorage.setItem('auth', JSON.stringify(auth))
}

// Returns a boolean if the user is logged in.
//
// Returns TRUE if there is an active user id, FALSE otherwise
//
export const isLoggedIn = () => {
  return getUserId() !== undefined
}

// Returns the user id of the logged in user, null otherwise
export const getUserId = () => {
  const auth = authFromStorage()

  return auth.user && auth.user.id
}

// Returns the user details retrieved from the authentication data
//
// Example:
//
// const user = getUser()
// console.log(user.fullName)
//
export const getUser = () => {
  const auth = authFromStorage()

  return auth.user
}

// Removes the authentication data, effectively "forgetting" the
// session information and logging the user out.
export const logout = () => {
  localStorage.removeItem('auth')
}

// Local method to fetch and decode the auth data from local storage
// If there is no local storage value, returns an empty object
const authFromStorage = () => {
  const auth = localStorage.getItem('auth')

  return auth ? JSON.parse(auth) : {}
}
