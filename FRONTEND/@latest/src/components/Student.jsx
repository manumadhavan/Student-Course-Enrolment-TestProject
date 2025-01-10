import React, { useEffect, useState } from 'react';

const StudentForm = ()=>
    {
        const[id, setId]= useState('');
        const[name, setName]= useState('');
        const[email, setEmail]= useState('');

        const handleSubmit = async(event)=>{

            event.preventDefault();
           
            const studentData = 
            {
                Id: id,
                Name: name,
                Email: email,
            };

            try
            {
               const response = await fetch('http://localhost:5299/api/Students/AddStudent',{

                method:'POST',
                headers:{
                    'Content-Type':'application/json',
                },
                body: JSON.stringify(studentData),
               });
               
               if(response.ok)
                {

                    const result = await response.json();
                    console.log('Student added:',result);
                    setId('');
                    setName('');
                    setEmail('');
                }
                else{
                    console.error('Failed to add Student:',response.statusText);
                }
            }
            catch(error)
            {
                console.error('Error:',error);
            }

        };

        return(

            <form onSubmit={handleSubmit}>
                <div>
                    <label>
                       ID:
                       <input
                       type="number"
                       value={id}
                       onChange={(e) => setId(e.target.value)}
                       required
                       />
                       
                    </label>
                </div>

                <div>
                    <label>
                       Name:
                       <input
                       type="text"
                       value={name}
                       onChange={(e) => setName(e.Target.Value)}
                       required
                       />
                       
                    </label>
                </div>


                <div>
                    <label>
                       Email:
                       <input
                       type="email"
                       value={email}
                       onChange={(e) => setEmail(e.Target.Value)}
                       required
                       />
                       
                    </label>
                </div>
                
            </form> 
        )
    }