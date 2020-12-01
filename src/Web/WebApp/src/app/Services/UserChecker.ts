import { Injectable } from '@angular/core';
import { User } from 'firebase';
import { AppUser } from '../Models/appuser';
import { UsersService } from './API/users.service';


@Injectable({
    providedIn: 'root',
})

export class UserChecker {

    constructor(private userService: UsersService)
    {}

    /**
     * Support the querying of user data stored within the API
     * @param user : firebase user
     */
    public tryReadOrCreateUserIfNotExits(user:User){
        console.log("tryReadOrCreateUserIfNotExits");

        this.userService.GetUserByObjectId(user.uid).then(res => {
            if(res.status != 200){
                //we need to create an AppUser and create one!
                let appUser : AppUser = {
                    objectId : user.uid,
                    email : user.email,
                    displayName: user.displayName
                };

                this.userService.CreateUser(appUser).then(res => {
                    if(res.status === 201)
                        console.log("user created");
                });
            }
        });
    }
}
