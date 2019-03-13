import React from 'react';
import {Table} from 'reactstrap';

const Details = ({
    client
}) => (
        <div className='client-details'>
            <Table>
                <tbody>
                    <tr>
                        <td>Company Name: BTIG</td>
                        <td>Last run date: DD/MM/YYY</td>
                    </tr>
                    <tr>
                        <td>Number of users: 2</td>
                        <td>Status: Active</td>
                    </tr>
                </tbody>
            </Table>
        </div>
    )

export default Details