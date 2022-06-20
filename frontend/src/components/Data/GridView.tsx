import { IRootBornObject } from '../../assets/Types'

export const GridView = (props:{regions:IRootBornObject[]}) => {
    const {regions} = props
  return (
    <>{regions.map((data:IRootBornObject)=>{


        return<div>
            <h1>{data.region}</h1>
        </div>
    })}
    </>
  )
}
