export function setToken(token) {
  localStorage.setItem('token', JSON.stringify(token))
}

export function getToken() {
  const token = localStorage.getItem('token')
  if (token) {
    return JSON.parse(token)
  }
  return null
}

export function removeToken() {
  localStorage.removeItem('token')
}
