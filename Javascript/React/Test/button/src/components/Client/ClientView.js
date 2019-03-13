import React from 'react';
import Details from './ClientBody/Details';
import Subscriptions from './ClientBody/Subscriptions';


const ClientView = ({
    props
}) => (
        <div>
            <div className='header'>

            </div>
            <div className='body'>
                <Details/>
                <hr/>
                <Subscriptions/>
            </div>
        </div>
    )


export default ClientView