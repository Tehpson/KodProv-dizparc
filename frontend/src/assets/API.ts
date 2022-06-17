import Axios from 'axios'

//creat connection to API
export const BackendAPI = Axios.create({
	baseURL: 'https://localhost:7134/api/'
})