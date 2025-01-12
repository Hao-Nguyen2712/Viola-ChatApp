import { createStore, storeKey } from 'vuex'
const store = createStore({
  state() {
    loginMessage: null
  },
  mutations: {
    setLoginMessage(state, message) {
      state.loginMessage = message
    },
    clearLoginMessage(state) {
      state.loginMessage = null // Xóa thông báo
    },
  },
  actions: {
    setLoginMessage({ commit }, message) {
      commit('setLoginMessage', message)
    },
    clearLoginMessage({ commit }) {
      commit('clearLoginMessage')
    },
  },
  getters: {
    loginMessage: (state) => state.loginMessage,
  },
})

export default store
