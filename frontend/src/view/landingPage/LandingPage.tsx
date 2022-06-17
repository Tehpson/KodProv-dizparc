import { AxiosError } from 'axios'
import { useEffect, useState } from 'react'
import { BackendAPI } from '../../assets/API'
import { IBornObject, IRootBornObject } from '../../assets/Types'

export const LandingPage = () => {
    const [data, setData] = useState<IRootBornObject[] | null>()
    const [flag, setFlag] = useState<boolean>(false)
    const [error, setError] = useState<AxiosError | null>()

    useEffect(() => {
        BackendAPI.get<IRootBornObject[]>(`born`)
            .then((res) => {
                console.log(res.data)

                res.data?.length > 0 ? setData(res.data) : setData(null)
            })
            .then(() => setFlag(true))
            .catch((error: AxiosError) => setError(error))
    }, [])

    return <div></div>
}
