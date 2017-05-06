<?php

class UserMapper extends Mapper
{
    public function getUser()
    {
        $stmt = $this->db->query("SELECT * FROM User");
        $results = [];
        while ($row = $stmt->fetch()) {
            $results[] = new UserEntity($row);
        }
        return $results;
    }

    public function getUserById($user_id)
    {
        $stmt = $this->db->prepare("SELECT * FROM User WHERE id = :user_id");
        $result = $stmt->execute(["user_id" => $user_id]);
        if ($result) {
            return new UserEntity($stmt->fetch());
        }
    }
}
