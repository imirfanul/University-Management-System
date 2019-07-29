using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemWebApp.Gateway;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Manager
{
    public class RoomManager
    {
        private RoomGateway roomGateway;

        public RoomManager()
        {
            roomGateway=new RoomGateway();
        }

        public List<Room> GetAllRoomCode()
        {
            return roomGateway.GetAllRoomCode();
        }

        public List<SelectListItem> GetAllRoomCodeList()
        {
            List<Room> Rooms = GetAllRoomCode();
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem()
            {
                Text = "--Select--",
                Value = ""
            });
            foreach (Room room in Rooms)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = room.RoomCode;
                selectListItem.Value = room.Id.ToString();
                selectListItems.Add(selectListItem);
            }
            return selectListItems;
        }
    }
}