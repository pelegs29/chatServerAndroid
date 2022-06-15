import React, {useContext, useState} from 'react';
import {Container} from "react-bootstrap";
import "./sideframe.css"
import {idContext, UsersListApp} from "../MainFrame/MainFrame";
import MyConversation from "../myConversation/MyConversation";
import AddContactsWin from "../addContactsWIn/addContactsWin";
import SearchBox from "../SearchBox/SearchBox";
import {useNavigate} from "react-router-dom";


function SideFrame({activeConv, setActiveConv,isSend, setIsSend,closeConnection}) {

    //the search Text
    const [searchQuery, setSearchQuery ] = useState("")

    //isAdd is use to render the page after new contact is add
    const [IsAdd,setIsAdd] = useState(true)

    let navigate = useNavigate();

    //idUser - is the user objects that logged in
    const idUser = useContext(idContext);
    const userist = useContext(UsersListApp);

    function logout() {
        closeConnection();
        navigate("/");
    }

    return (
        <div className="  border sideFrame  d-flex flex-column position-relative">
            {/*the username ob the left top*/}
            <Container className="rounded-0 userNameSide text-secondary fw-bold pt-1">
                <i className="bi bi-person-circle me-2"/>
                Hello {idUser.name}
                {/*the logout option*/}
                <div className={"d-flex justify-content-end"}>
                    <span id={"logoutText"} className={""} onClick={logout}>
                        <i className="bi bi-lock-fill"/> Logout
                    </span>
                </div>
            </Container>
            {/*the search */}
            <SearchBox  setSearchQuery={setSearchQuery} className="userNameSide"/>
            {/*the list of conversation of the user */}
            <div className="flex-grow-1 convList">
                <MyConversation  activeConv={activeConv} setActiveConv={setActiveConv } searchQuery={searchQuery} isSend={isSend} setIsSend={setIsSend}/>
            </div>
            {/*the add New Conversation button click*/}
            <AddContactsWin  setActiveConv={setActiveConv} setIsAdd={setIsAdd} isAdd={IsAdd} />
        </div>
    )
}

export default SideFrame;