import { AxiosError } from 'axios'
import { useEffect, useState } from 'react'
import { BackendAPI } from '../../assets/API'
import { IRootBornObject } from '../../assets/Types'
import { GridView } from '../../components/Data/GridView'

export const LandingPage = () => {
    const [bornData, setBornData] = useState<IRootBornObject[] | null>()
    const [flag, setFlag] = useState<boolean>(false)
    const [error, setError] = useState<AxiosError | null>()

    useEffect(() => {
        BackendAPI.get<IRootBornObject[]>(`born`)
            .then((res) => {
                console.log(res.data)

                res.data?.length > 0 ? setBornData(res.data) : setBornData(null)
            })
            .then(() => setFlag(true))
            .catch((error: AxiosError) => setError(error))
    }, [])

    return (
        <div>
            {flag ? (
                bornData ? (
                    <GridView regions={bornData} />
                ) : (
                    <div>No Data</div>
                )
            ) : (
                <div>Loading...</div>
            )}
        </div>
    )
}
