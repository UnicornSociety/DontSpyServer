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

    public function getUserByEMail($user_email)
    {
        $stmt = $this->db->prepare("SELECT * FROM user WHERE email = :user_email");
        $result = $stmt->execute(["user_email" => $user_email]);
        if ($result) {
            return new UserEntity($stmt->fetch());
        }
    }

    public function save(UserEntity $user)
    {
        $stmt = $this->db->prepare("INSERT INTO user(id, displayname, email) VALUES (:id, :displayname, :email)");
        $result = $stmt->execute([
            "id" => $user->getId(),
            "displayname" => $user->getDisplayname(),
            "email" => $user->getEmail()
        ]);
        if (!$result) {
            throw new Exception("Could not save record");
        }
    }
}
