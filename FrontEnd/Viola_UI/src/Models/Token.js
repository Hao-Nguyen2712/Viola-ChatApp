export default class {
  constructor(accessToken, refreshToken) {
    this.accessToken = accessToken
    this.refreshToken = refreshToken
  }

  getAccessToken() {
    return this.accessToken
  }
  getRefreshToken() {
    return this.refreshToken
  }
}
