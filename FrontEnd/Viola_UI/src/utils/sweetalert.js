import Swal from 'sweetalert2'

export function showSucess(message) {
  Swal.fire({
    icon: 'success',
    title: 'Success!',
    text: message,
  })
}

export function showError(message) {
  Swal.fire({
    icon: 'error',
    title: 'Error!',
    text: message,
  })
}

export function showWarning(message) {
  Swal.fire({
    icon: 'warning',
    title: 'Warning!',
    text: message,
  })
}

let swalLoading = true

export function showLoading(message = 'Waiting...') {
  swalLoading = Swal.fire({
    title: message,
    allowOutsideClick: false,
    didOpen: () => {
      Swal.showLoading()
    },
    showConfirmButton: false,
  })
}

export function closeLoading() {
  if (swalLoading) {
    swalLoading.close()
  }
}
